// ReSharper disable once CheckNamespace
namespace Modern.Additional.Behaviors
{
    using Modern.Additional.Controls.Internal;

    public sealed class ChangeScope : DisposableObject
    {
        private readonly GlowWindowBehavior behavior;

        public ChangeScope(GlowWindowBehavior behavior)
        {
            this.behavior = behavior;
            this.behavior.DeferGlowChangesCount++;
        }

        protected override void DisposeManagedResources()
        {
            this.behavior.DeferGlowChangesCount--;
            if (this.behavior.DeferGlowChangesCount == 0)
            {
                this.behavior.EndDeferGlowChanges();
            }
        }
    }
}