using System.Collections.Generic;

namespace MvvmCross.AdvancedRecyclerView.Swipe.State
{
    public class SwipeItemPinnedStateController
    {
        private readonly Dictionary<int, bool> _pinnedStateDictionary = new Dictionary<int, bool>();

        public void SetPinnedState(int atPosition, bool isPinned)
        {
            if (!_pinnedStateDictionary.ContainsKey(atPosition))
                _pinnedStateDictionary.Add(atPosition, false);
            _pinnedStateDictionary[atPosition] = isPinned;
        }

        public bool IsPinned(int atPosition) => _pinnedStateDictionary.ContainsKey(atPosition) && _pinnedStateDictionary[atPosition];

        public void ResetState() => _pinnedStateDictionary.Clear();
    }
}