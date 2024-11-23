
    public interface IOutputSceneArgs
    {
        IInputSceneArgs NextSceneInputArgs { get; }
    }

    public abstract class OutputSceneArgs : IOutputSceneArgs
    {
        protected OutputSceneArgs(IInputSceneArgs nextSceneInputArgs)
        {
            NextSceneInputArgs = nextSceneInputArgs;
        }

        public IInputSceneArgs NextSceneInputArgs { get; }
    }

    public class OutputGameplayArgs : OutputSceneArgs
    {
        public OutputGameplayArgs(IInputSceneArgs nextSceneInputArgs) : base(nextSceneInputArgs)
        {
        }
    }

    public class OutputMainMenuArgs : OutputSceneArgs
    {
        public OutputMainMenuArgs(IInputSceneArgs nextSceneInputArgs) : base(nextSceneInputArgs)
        {
        }
    }

    public class OutpurBootstrapArgs : OutputSceneArgs
    {
        public OutpurBootstrapArgs(IInputSceneArgs nextSceneInputArgs) : base(nextSceneInputArgs)
        {
        }
    }