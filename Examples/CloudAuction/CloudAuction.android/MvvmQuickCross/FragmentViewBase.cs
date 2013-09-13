using Android.App;
using Android.Views;

namespace MvvmQuickCross
{
    public class FragmentViewBase<ViewModelType> : Fragment where ViewModelType : ViewModelBase
    {
        private bool areHandlersAdded;
        protected ViewModelType ViewModel { get; private set; }
        protected ViewDataBindings Bindings { get; private set; }

        protected void Initialize(View view, ViewModelType viewModel, string idPrefix = null)
        {
            Bindings = new ViewDataBindings(view, viewModel, idPrefix ?? this.GetType().Name);
            ViewModel = viewModel;
            EnsureHandlersAreAdded();
            Bindings.EnsureCommandBindings();
            ViewModel.RaisePropertiesChanged();
        }

        protected virtual void AddHandlers()
        {
            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            Bindings.AddHandlers();
        }

        protected virtual void RemoveHandlers()
        {
            Bindings.RemoveHandlers();
            ViewModel.PropertyChanged -= ViewModel_PropertyChanged;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            Bindings.UpdateView(propertyName);
        }

        public override void OnPause()
        {
            EnsureHandlersAreRemoved();
            base.OnPause();
        }

        public override void OnResume()
        {
            base.OnResume();
            EnsureHandlersAreAdded();
        }

        private void EnsureHandlersAreAdded()
        {
            if (areHandlersAdded) return;
            AddHandlers();
            areHandlersAdded = true;
        }

        private void EnsureHandlersAreRemoved()
        {
            if (!areHandlersAdded) return;
            RemoveHandlers();
            areHandlersAdded = false;
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName);
        }
    }
}