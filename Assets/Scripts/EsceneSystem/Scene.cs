public abstract class Scene : IUpdate, IRenderable
{
    public virtual void OnLoad() { }
    public abstract void Update();
    public virtual void OnUnload() { }
    public abstract void Render();
}