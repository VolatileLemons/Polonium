using System;

public class GameObject
{
    public GameObject(PoloniumEngine.Polonium polonium, string name = "")
    {
        Polonium = polonium;
        name = Name;
        polonium.gameObjects.Add(this);
        init();
    }

    public PoloniumEngine.Polonium Polonium;
    public string Name;

    public virtual void init() { }
    public virtual void update() { }
    public virtual void draw(PoloniumEngine.Visuals.Camera camera = null) { }
}