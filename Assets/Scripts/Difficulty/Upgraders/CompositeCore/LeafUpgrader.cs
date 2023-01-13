namespace LimboOfCeres.Scripts.Difficulty.Upgraders.CompositeCore
{
    public abstract class LeafUpgrader : Upgrader
    {
        protected override bool IsComposite => false;

        public override bool IsAtLimit => false;
    }
}
