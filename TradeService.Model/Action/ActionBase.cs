namespace TradeService.Model.Action
{
	/// <summary>
	/// Represent basic functionality of action
	/// </summary>
	public abstract class ActionBase
	{
		/// <summary>
		/// Apply action
		/// </summary>
		public abstract void Apply();

		/// <summary>
		/// Regain action, action reversed present
		/// </summary>
		public abstract void Regain();
	}
}