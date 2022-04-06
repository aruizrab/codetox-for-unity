using UnityEngine;
using UnityEngine.InputSystem;

namespace Codetox.Input
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.Input.ActionRebindPersistence.Path,
        fileName = nameof(InputActionAssetRebindPersistenceManager))]
    public class InputActionAssetRebindPersistenceManager : ScriptableObject
    {
        [SerializeField] private InputActionAsset inputActionAsset;

        private void OnEnable()
        {
            LoadRebinds();
        }

        public void LoadRebinds()
        {
            var rebinds = PlayerPrefs.GetString(inputActionAsset.name + "-rebinds");
            if (!string.IsNullOrEmpty(rebinds)) inputActionAsset.LoadBindingOverridesFromJson(rebinds);
        }

        public void SaveRebinds()
        {
            var rebinds = inputActionAsset.SaveBindingOverridesAsJson();
            PlayerPrefs.SetString(inputActionAsset.name + "-rebinds", rebinds);
        }

        public void ResetRebinds()
        {
            inputActionAsset.RemoveAllBindingOverrides();
            PlayerPrefs.DeleteKey(inputActionAsset.name + "-rebinds");
        }
    }
}