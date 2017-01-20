public static class Config
{
	public const float TICK_INTERVAL = 1f / 10f;
	public const float VIEW_DELAY = 1f / 5f;

	public const string VIEW_PATH = "Views/";
	public const string UI_PATH = "UI/Dialogs/";

	public const string MESSAGE_DIALOG_PATH = UI_PATH + "MessageDialog";

	public const string GREETINGS_MESSAGE = "This is a project that uses MVC pattern.\n\nThe simulation is running at 10 ticks per second while the rendering is running at full blast. The animation is linearly interpolating towards the model with a slight delay.\n\nClick anywhere on the screen to spawn objects that move circularly.";
}
