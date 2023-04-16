using SFML.Graphics;
using SFML.Window;

namespace Lab4_1.Infrastructure.Draw;

interface ICanvas
{
    void Draw();

    // void DrawLine();
    // void FillPolygon();
    // void DrawCircle();
    // void FillCircle();
}

public class Canvas : ICanvas
{
    private RenderWindow _window;

    public Canvas(uint width, uint height)
    {
        // Create the main window
        _window = new RenderWindow(new VideoMode(800, 600), "SFML Works!");
    }

    public void Draw()
    {
        _window.Closed += new EventHandler(OnClose);

        Color windowColor = new Color(0, 192, 255);

        // Start the game loop
        while (_window.IsOpen)
        {
            // Process events
            _window.DispatchEvents();

            // Clear screen
            _window.Clear(windowColor);

            // Update the window
            _window.Display();
        } //End game loop
    } //End Main()


    private void OnClose(object sender, EventArgs e)
    {
        // Close the window when OnClose event is received
        RenderWindow window = (RenderWindow)sender;
        window.Close();
    }
}