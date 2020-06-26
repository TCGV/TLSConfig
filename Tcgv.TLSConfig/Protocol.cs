using Microsoft.Win32;

namespace Tcgv.TLSConfig
{
    public class Protocol
    {
        public Protocol(string protocolName)
        {
            this.protocolName = protocolName;
        }

        public bool IsServerPartiallyOrFullyEnabled()
        {
            return IsPartiallyOrFullyEnabled(KeyNames.SERVER);
        }

        public bool IsClientPartiallyOrFullyEnabled()
        {
            return IsPartiallyOrFullyEnabled(KeyNames.CLIENT);
        }

        public void EnableAll()
        {
            EnableServer();
            EnableClient();
        }

        public void EnableServer()
        {
            Remove(KeyNames.SERVER);
        }

        public void EnableClient()
        {
            Remove(KeyNames.CLIENT);
        }

        public void DisableAll()
        {
            DisbleServer();
            DisableClient();
        }

        public void DisbleServer()
        {
            Write(KeyNames.SERVER, KeyNames.ENABLED, 0);
            Write(KeyNames.SERVER, KeyNames.DISABLED_BY_DEFAULT, 1);
        }

        public void DisableClient()
        {
            Write(KeyNames.CLIENT, KeyNames.ENABLED, 0);
            Write(KeyNames.CLIENT, KeyNames.DISABLED_BY_DEFAULT, 1);
        }

        private RegistryKey GetRoot()
        {
            return Registry.LocalMachine
                .OpenSubKey(KeyNames.SECURTY_PROTOCOLS)
                .OpenSubKey(protocolName);
        }

        private bool IsPartiallyOrFullyEnabled(string keyName)
        {
            var root = GetRoot();
            if (root == null)
                return true;
            var serverOrClient = root.OpenSubKey(keyName);
            var enabled = (int?)serverOrClient?.GetValue(KeyNames.ENABLED);
            var disabledByDefault = (int?)serverOrClient?.GetValue(KeyNames.DISABLED_BY_DEFAULT);
            return (!enabled.HasValue || enabled.Value != 0) &&
                (!disabledByDefault.HasValue || disabledByDefault != 1);
        }

        private void Write(string subKeyName, string valueName, int value)
        {
            var protocols = Registry.LocalMachine.OpenSubKey(KeyNames.SECURTY_PROTOCOLS, true);
            var root = protocols.OpenSubKey(protocolName, true) ?? protocols.CreateSubKey(protocolName);
            var sub = root.OpenSubKey(subKeyName, true) ?? root.CreateSubKey(subKeyName);
            sub.SetValue(valueName, value, RegistryValueKind.DWord);
        }

        private void Remove(string subKeyName)
        {
            var protocols = Registry.LocalMachine.OpenSubKey(KeyNames.SECURTY_PROTOCOLS, true);
            var root = protocols.OpenSubKey(protocolName, true);
            if (root?.OpenSubKey(subKeyName, true) != null)
                root.DeleteSubKey(subKeyName);
        }

        private string protocolName;
    }
}
