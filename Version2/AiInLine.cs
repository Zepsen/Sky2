using System;

namespace Sky.Version2
{
    public class AiInLine
    {
        private Map _map;
        public AiInLine(int[] arr)
        {
            _map = new Map(arr);
        }

        /// <summary>
        /// Run
        /// </summary>
        public void Run()
        {            
            _map.SetDefaultValues();

            if (_map.ValidateState())
                SaveState();
            else throw new Exception("Wrong default arfs");

            Resolve();            
        }

        /// <summary>
        /// Main resolver
        /// </summary>
        private void Resolve()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Save current state
        /// </summary>
        private void SaveState()
        {
            throw new NotImplementedException();
        }

       

        
    }
}
