namespace IT_STEP
{
    public class Composite : Component
    {
        private readonly List<Component> _children = new();

        public override bool IsComposite => true;

        public override void Add(Component component)
        {
            _children.Add(component);
        }

        public override void Remove(Component component)
        {
            _children.Remove(component);
        }

        public override string Operation()
        {
            var result = string.Join("+", _children.Select(c => c.Operation()));
            return $"Branch({result})";
        }
    }
}
