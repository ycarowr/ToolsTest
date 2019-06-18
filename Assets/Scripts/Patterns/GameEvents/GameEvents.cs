using Patterns;

namespace Patterns.GameEvents
{
    //----------------------------------------------------------------------------------------------------------

    public class GameEvents : Observer<GameEvents>
    {
        
    }

    //----------------------------------------------------------------------------------------------------------

    #region Game Events Definition

    /// <summary>
    ///      Broadcast of the event to the Listeners.
    /// </summary>
    public interface ISampleEvent1 : ISubject
    {
        void OnISampleEvent1();
    }

    /// <summary>
    ///      Broadcast of the event to the Listeners.
    /// </summary>
    public interface ISampleEvent2 : ISubject
    {
        void OnISampleEvent2();
    }

    #endregion

    //----------------------------------------------------------------------------------------------------------
}