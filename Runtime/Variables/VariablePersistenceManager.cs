using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Codetox.Variables
{
    [AddComponentMenu(Framework.MenuRoot.Variables.Persistence)]
    public class VariablePersistenceManager : MonoBehaviour
    {
        [SerializeField] private VariableManager variableManager;
        [SerializeField] private LoadingStrategy loadingStrategy = LoadingStrategy.OnEnable;
        [SerializeField] private SavingStrategy savingStrategy = SavingStrategy.OnDisable;
        [SerializeField] private string fileName = "save";

        private void Awake()
        {
            if (loadingStrategy.HasFlag(LoadingStrategy.Awake)) Load();
        }

        private void Start()
        {
            if (loadingStrategy.HasFlag(LoadingStrategy.Start)) Load();
        }

        private void OnEnable()
        {
            if (loadingStrategy.HasFlag(LoadingStrategy.OnEnable)) Load();
        }

        private void OnDisable()
        {
            if (savingStrategy.HasFlag(SavingStrategy.OnDisable)) Save();
        }

        private void OnDestroy()
        {
            if (savingStrategy.HasFlag(SavingStrategy.OnDestroy)) Save();
        }

        public void Save()
        {
            var path = Application.persistentDataPath + $"/{fileName}.data";
            var map = new VariableMap();
            var binaryFormatter = new BinaryFormatter();
            var file = File.Create(path);

            map.Load(variableManager.variables);
            binaryFormatter.Serialize(file, map);
            file.Close();
        }

        public void Load()
        {
            var path = Application.persistentDataPath + $"/{fileName}.data";
            if (!File.Exists(path)) return;

            var binaryFormatter = new BinaryFormatter();
            var file = File.Open(path, FileMode.Open);
            var map = (VariableMap) binaryFormatter.Deserialize(file);

            map.Restore(variableManager.variables);
            file.Close();
        }

        [Flags]
        private enum LoadingStrategy
        {
            Awake = 1,
            Start = 2,
            OnEnable = 4
        }

        [Flags]
        private enum SavingStrategy
        {
            OnDisable = 1,
            OnDestroy = 2
        }
    }
}