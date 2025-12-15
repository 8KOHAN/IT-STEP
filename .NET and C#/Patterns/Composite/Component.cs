namespace IT_STEP
{
    public abstract class Component
    {
        public abstract string Operation();

        public virtual void Add(Component component)
        {
            throw new NotSupportedException();
        }

        public virtual void Remove(Component component)
        {
            throw new NotSupportedException();
        }

        public virtual bool IsComposite => false;
    }
}
