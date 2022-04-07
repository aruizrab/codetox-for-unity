namespace Codetox
{
    public static class Framework
    {
        public static class MenuRoot
        {
            public const string Path = "Codetox/";

            public static class Pooling
            {
                public const string Path = MenuRoot.Path + "Pooling/";
                
                public const string GameObject = Path + "GameObject Pool";
                public const string ParticleSystem = Path + "ParticleSystem Pool";
            }

            public static class GameEvents
            {
                public const string Path = MenuRoot.Path + "Game Events/";
                
                public const string Void = Path + "Void";
                public const string Bool = Path + "Bool";
                public const string Float = Path + "Float";
                public const string Int = Path + "Int";
                public const string String = Path + "String";
                public const string Vector2 = Path + "Vector2";
                public const string Vector3 = Path + "Vector3";
                public const string GameObject = Path + "GameObject";
                public const string Component = Path + "Component";
                public const string Reference = Path + "Reference";
                public const string List = Path + "List";
                public const string Dictionary = Path + "Dictionary";
            }

            public static class GameEventListeners
            {
                public const string Path = MenuRoot.Path + "Game Event Listeners/";
                
                public const string Void = Path + "Void Game Event Listener";
                public const string Bool = Path + "Bool Game Event Listener";
                public const string Float = Path + "Float Game Event Listener";
                public const string Int = Path + "Int Game Event Listener";
                public const string String = Path + "String Game Event Listener";
                public const string Vector2 = Path + "Vector2 Game Event Listener";
                public const string Vector3 = Path + "Vector3 Game Event Listener";
                public const string GameObject = Path + "GameObject Game Event Listener";
                public const string Component = Path + "Component Game Event Listener";
                public const string Reference = Path + "Reference Game Event Listener";
                public const string List = Path + "List Game Event Listener";
                public const string Dictionary = Path + "Dictionary Game Event Listener";
            }

            public static class Variables
            {
                public const string Path = MenuRoot.Path + "Variables/";
                
                public const string Void = Path + "Void";
                public const string Bool = Path + "Bool";
                public const string Float = Path + "Float";
                public const string Int = Path + "Int";
                public const string String = Path + "String";
                public const string Vector2 = Path + "Vector2";
                public const string Vector3 = Path + "Vector3";
                public const string GameObject = Path + "GameObject";
                public const string Component = Path + "Component";
                public const string Reference = Path + "Reference";
                public const string List = Path + "List";
                public const string Dictionary = Path + "Dictionary";
            }

            public static class Input
            {
                public const string Path = MenuRoot.Path + "Input/";

                public static class ActionHandlers
                {
                    public const string Path = Input.Path + "Action Handlers/";
                    
                    public const string Void = Path + "Void";
                    public const string Bool = Path + "Bool";
                    public const string Float = Path + "Float";
                    public const string Int = Path + "Int";
                    public const string String = Path + "String";
                    public const string Vector2 = Path + "Vector2";
                    public const string Vector3 = Path + "Vector3";
                    public const string GameObject = Path + "GameObject";
                    public const string Component = Path + "Component";
                    public const string Reference = Path + "Reference";
                    public const string List = Path + "List";
                    public const string Dictionary = Path + "Dictionary";
                }

                public static class ActionRebind
                {
                    public const string Path = Input.Path + "Action Rebind Manager";
                }
                
                public static class ActionRebindPersistence
                {
                    public const string Path = Input.Path + "Action Rebind Persistence Manager";
                }
            }
        }
        
        public static class DataTypes
        {
            public const string Void = "Void";
            public const string Bool = "Bool";
            public const string Float = "Float";
            public const string Int = "Int";
            public const string String = "String";
            public const string Vector2 = "Vector2";
            public const string Vector3 = "Vector3";
            public const string GameObject = "GameObject";
            public const string Component = "Component";
            public const string Reference = "Reference";
            public const string List = "List";
            public const string Dictionary = "Dictionary";
        }
    }
}