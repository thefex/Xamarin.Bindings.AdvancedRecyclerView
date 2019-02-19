using System;
using Android.Animation;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Java.Interop;

namespace RecordGuard.ListSample.Android.Extensions.CustomViews
{
    public class PlayPauseDrawable : Drawable
    {
        private readonly Path mLeftPauseBar = new Path();
        private readonly Path mRightPauseBar = new Path();
        private readonly Paint mPaint = new Paint();
        private readonly RectF mBounds = new RectF();
        private float mPauseBarWidth;
        private float mPauseBarHeight;
        private float mPauseBarDistance;

        private float mWidth;
        private float mHeight;

        private float mProgress = 1;
        private bool mIsPlay = true;

        public PlayPauseDrawable(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public PlayPauseDrawable(Color fillColor)
        {
            mPaint.AntiAlias = true;
            mPaint.SetStyle(Paint.Style.Fill);
            mPaint.Color = fillColor;
        }

        protected override void OnBoundsChange(Rect bounds)
        {
            base.OnBoundsChange(bounds);
            mBounds.Set(bounds);
            mWidth = mBounds.Width();
            mHeight = mBounds.Height();

            mPauseBarHeight = mHeight / 2.5f;
            mPauseBarWidth = mPauseBarHeight / 2.5f;
            mPauseBarDistance = mPauseBarWidth / 1.5f;
        }

        public override void Draw(Canvas canvas)
        {
            mLeftPauseBar.Rewind();
            mRightPauseBar.Rewind();

            // The current distance between the two pause bars.
            float barDist = lerp(mPauseBarDistance, 0, mProgress) - 1;
            // The current width of each pause bar.
            float barWidth = lerp(mPauseBarWidth, mPauseBarHeight / 2f, mProgress);
            // The current position of the left pause bar's top left coordinate.
            float firstBarTopLeft = lerp(0, barWidth, mProgress);
            // The current position of the right pause bar's top right coordinate.
            float secondBarTopRight = lerp(2 * barWidth + barDist, barWidth + barDist, mProgress);

            // Draw the left pause bar. The left pause bar transforms into the
            // top half of the play button triangle by animating the position of the
            // rectangle's top left coordinate and expanding its bottom width.
            mLeftPauseBar.MoveTo(0, 0);
            mLeftPauseBar.LineTo(firstBarTopLeft, -mPauseBarHeight);
            mLeftPauseBar.LineTo(barWidth, -mPauseBarHeight);
            mLeftPauseBar.LineTo(barWidth, 0);
            mLeftPauseBar.Close();

            // Draw the right pause bar. The right pause bar transforms into the
            // bottom half of the play button triangle by animating the position of the
            // rectangle's top right coordinate and expanding its bottom width.
            mRightPauseBar.MoveTo(barWidth + barDist, 0);
            mRightPauseBar.LineTo(barWidth + barDist, -mPauseBarHeight);
            mRightPauseBar.LineTo(secondBarTopRight, -mPauseBarHeight);
            mRightPauseBar.LineTo(2 * barWidth + barDist, 0);
            mRightPauseBar.Close();

            canvas.Save();

            // Translate the play button a tiny bit to the right so it looks more centered.
            canvas.Translate(lerp(0, mPauseBarHeight / 8f, mProgress), 0);

            // (1) Pause --> Play: rotate 0 to 90 degrees clockwise.
            // (2) Play --> Pause: rotate 90 to 180 degrees clockwise.
            float rotationProgress = mIsPlay ? 1 - mProgress : mProgress;
            float startingRotation = mIsPlay ? 90 : 0;
            canvas.Rotate(lerp(startingRotation, startingRotation + 90, rotationProgress), mWidth / 2f, mHeight / 2f);

            // Position the pause/play button in the center of the drawable's bounds.
            canvas.Translate(mWidth / 2f - ((2 * barWidth + barDist) / 2f), mHeight / 2f + (mPauseBarHeight / 2f));

            // Draw the two bars that form the animated pause/play button.
            canvas.DrawPath(mLeftPauseBar, mPaint);
            canvas.DrawPath(mRightPauseBar, mPaint);

            canvas.Restore();
        }

        public void SetPlay()
        {
            mIsPlay = true;
            mProgress = 1;
        }

        public void SetPause()
        {
            mIsPlay = false;
            mProgress = 0;
        }

        public Animator GetPausePlayAnimator()
        {
            Animator anim = ObjectAnimator.OfFloat(this, "progress", mIsPlay ? 1 : 0, mIsPlay ? 0 : 1);
            anim.AnimationStart += (e, a) => mIsPlay = !mIsPlay;

            return anim;
        }

        public bool IsPlay()
        {
            return mIsPlay;
        }

        [Export("setProgress")]
        private void SetProgress(float progress)
        {
            mProgress = progress;
            InvalidateSelf();
        }

        [Export("getProgress")]
        private float GetProgress()
        {
            return mProgress;
        }

        public override void SetAlpha(int alpha)
        {
            mPaint.Alpha = (alpha);
            InvalidateSelf();
        }

        public override void SetColorFilter(ColorFilter cf)
        {
            mPaint.SetColorFilter(cf);
            InvalidateSelf();
        }

        public override int Opacity => (int) Format.Translucent;

        /**
         * Linear interpolate between a and b with parameter t.
         */
        private static float lerp(float a, float b, float t)
        {
            return a + (b - a) * t;
        }
    }
}