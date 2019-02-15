using System;
using Android.Animation;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using Java.Interop;

namespace RecordGuard.ListSample.Android.Extensions.CustomViews
{
    [Register("com.recordguard.PlayPauseView")]
    public class PlayPauseView : FrameLayout {
        private static readonly long PlayPauseAnimationDuration = 200;

        private PlayPauseDrawable mDrawable;
        private Paint mPaint = new Paint();
        private int mPauseBackgroundColor;
        private int mPlayBackgroundColor;

        private AnimatorSet mAnimatorSet;
        private int mBackgroundColor;
        private int mWidth;
        private int mHeight;

        protected PlayPauseView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public PlayPauseView(Context context) : base(context) {
            mPlayBackgroundColor = Color.Blue;
            mPauseBackgroundColor = Color.Cyan;
            Color fillColor = Color.White;
            mDrawable = new PlayPauseDrawable(fillColor);
            init(context);
        }

        public PlayPauseView(Context context, IAttributeSet attrs) : base(context, attrs) {
            TypedArray a = context.Theme.ObtainStyledAttributes(
                attrs,
                Resource.Styleable.PlayPauseView,
                0, 0);
            int fillColor;
            try {
                mPlayBackgroundColor = a.GetColor(Resource.Styleable.PlayPauseView_play_bg, Color.Blue);
                mPauseBackgroundColor = a.GetColor(Resource.Styleable.PlayPauseView_pause_bg, Color.Cyan);
                fillColor = a.GetColor(Resource.Styleable.PlayPauseView_fill_color, Color.White);
            } finally {
                a.Recycle();
            }
            mDrawable = new PlayPauseDrawable(new Color(fillColor));
            init(context);
        }

        private void init(Context context) {
            SetWillNotDraw(false);
            mPaint.AntiAlias = true;
            mPaint.SetStyle(Paint.Style.Fill);
            mDrawable.SetCallback(this);

            mBackgroundColor = mPlayBackgroundColor;
        }


        protected override IParcelable OnSaveInstanceState() {
            var superState = base.OnSaveInstanceState();
            SavedState ss = new SavedState(superState);
            ss.IsPlay = mDrawable.IsPlay();
            return ss;
        }

        protected override void OnRestoreInstanceState(IParcelable state) {
            SavedState ss = (SavedState) state;
            base.OnRestoreInstanceState(ss.SuperState);
            InitStatus(ss.IsPlay);
            Invalidate();
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec) {
            int width = View.MeasureSpec.GetSize(widthMeasureSpec);
            int height = View.MeasureSpec.GetSize(heightMeasureSpec);
            int size = Math.Min(width, height);
            SetMeasuredDimension(
                View.MeasureSpec.MakeMeasureSpec(size, MeasureSpecMode.Exactly),
                View.MeasureSpec.MakeMeasureSpec(size, MeasureSpecMode.Exactly)
            );
        }

        protected override void OnSizeChanged(int w, int h, int oldw, int oldh) {
            base.OnSizeChanged(w, h, oldw, oldh);
            mDrawable.SetBounds(0, 0, w, h);
            mWidth = w;
            mHeight = h;

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                OutlineProvider = new ActionOutlineProvider((v, outline) =>
                {
                    outline.SetOval(0, 0, v.Width, v.Height);
                }); 
                ClipToOutline = (true);
            }
        }

        [Export("setColor")]
        public void SetColor(int color) {
            mBackgroundColor = color;
            Invalidate();
        }

        [Export("getColor")]
        public int GetColor() {
            return mBackgroundColor;
        }

        protected override bool VerifyDrawable(Drawable who) {
            return who == mDrawable || base.VerifyDrawable(who);
        }

        protected override void OnDraw(Canvas canvas) {
            base.OnDraw(canvas);
            mPaint.Color = new Color(mBackgroundColor);
            mPaint.AntiAlias = true;
            float radius = Math.Min(mWidth, mHeight) / 2f;
            canvas.DrawColor(Color.Transparent, PorterDuff.Mode.Clear);
            canvas.DrawCircle(mWidth / 2f, mHeight / 2f, radius, mPaint);
            mDrawable.Draw(canvas);
        }

        /**
     * Toogle the play/pause status
     */
        public void Toggle() {
            Toggle(true);
        }

        /**
     * Change status to play or pause
     *
     * @param isPlay for playing, false else
     */
        public void Change(bool isPlay) {
            Change(isPlay, true);
        }

        /**
     * Change status to play or pause
     *
     * @param isPlay   for playing, false else
     * @param withAnim false to change status without animation
     */
        public void Change(bool isPlay, bool withAnim) {
            if (mDrawable.IsPlay() == isPlay)
                return;
            Toggle(withAnim);
        }

        /**
     * Toogle the play/pause status
     *
     * @param withAnim false to change status without animation
     */
        public void Toggle(bool withAnim) {
            if (withAnim) {
                if (mAnimatorSet != null) {
                    mAnimatorSet.Cancel();
                }

                mAnimatorSet = new AnimatorSet();
                bool isPlay = mDrawable.IsPlay();
                ObjectAnimator colorAnim = ObjectAnimator.OfInt(this, "color", isPlay ? mPauseBackgroundColor : mPlayBackgroundColor);
                colorAnim.SetEvaluator(new ArgbEvaluator());
                Animator pausePlayAnim = mDrawable.GetPausePlayAnimator();
                mAnimatorSet.SetInterpolator(new DecelerateInterpolator());
                mAnimatorSet.SetDuration(PlayPauseAnimationDuration);
                mAnimatorSet.PlayTogether(colorAnim, pausePlayAnim);
                mAnimatorSet.Start();
            } else {
                bool isPlay = mDrawable.IsPlay();
                InitStatus(!isPlay);
                Invalidate();
            }
        }

        private void InitStatus(bool isPlay) {
            if (isPlay) {
                mDrawable.SetPlay();
                SetColor(mPlayBackgroundColor);
            } else {
                mDrawable.SetPause();
                SetColor(mPauseBackgroundColor);
            }
        }

        public bool IsPlay() {
            return mDrawable.IsPlay();
        }

        public bool IsPlaying
        {
            get => mDrawable.IsPlay();
            set
            {
                if (!IsPlaying != value)
                    Toggle();
            }
        }

        private class SavedState : BaseSavedState {
            public bool IsPlay { get; set; }

            public SavedState(IParcelable superState) : base(superState) {
            
            }

            public SavedState(Parcel @in) : base(@in) {
                IsPlay = @in.ReadByte() > 0;
            }

            public override void WriteToParcel(Parcel dest, ParcelableWriteFlags flags)
            {
                base.WriteToParcel(dest, flags);
                dest.WriteByte(IsPlay ? (sbyte) 1 : (sbyte) 0);
            }
        }
    
        private class ActionOutlineProvider : ViewOutlineProvider
        {
            private readonly Action<View, Outline> _outlineProviderAction;

            public ActionOutlineProvider(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
            {
            }

            public ActionOutlineProvider(Action<View, Outline> outlineProviderAction)
            {
                _outlineProviderAction = outlineProviderAction;
            }
        
            public override void GetOutline(View view, Outline outline)
            {
                _outlineProviderAction(view, outline);
            }
        }
    }
}