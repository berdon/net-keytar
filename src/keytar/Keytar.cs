using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Keytar
{
    public class Password
    {
        // TODO: Sigh.
        private static StringBuilder NULL_BUFFER = new StringBuilder(0);

        private enum KeytarResult
        {
            Success = 0,
            FailError = 1,
            FailNonFatal = 2
        }

        [DllImport(@"libnetkeytar_mac.dylib")]
        private static extern KeytarResult GetPassword(string service, string account, StringBuilder password, ref int passwordLength, StringBuilder error, ref int errorLength);
        [DllImport(@"libnetkeytar_mac.dylib")]
        private static extern KeytarResult SetPassword(string service, string account, string password, StringBuilder error, ref int errorLength);
        [DllImport(@"libnetkeytar_mac.dylib")]
        private static extern KeytarResult DeletePassword(string service, string account, StringBuilder error, ref int errorLength);

        public static bool TryGetPassword(string service, string account, out string password, out string error)
        {
            password = null;
            error = null;
            int passwordLength = -1;
            int errorLength = -1;

            // Grab result lengths        
            GetPassword(service, account, NULL_BUFFER, ref passwordLength, NULL_BUFFER, ref errorLength);

            // Build buffers
            var passwordBuffer = passwordLength > -1 ? new StringBuilder(passwordLength) : null;
            var errorBuffer = errorLength > -1 ? new StringBuilder(errorLength) : null;

            // Request the actual results
            var result = GetPassword(service, account, passwordBuffer, ref passwordLength, errorBuffer, ref errorLength);

            // Move the results to strings
            password = passwordBuffer?.ToString() ?? null;
            error = errorBuffer?.ToString() ?? null;

            // Return
            return result == KeytarResult.Success;
        }

        public static bool TrySetPassword(string service, string account, string password, out string error)
        {
            error = null;
            int errorLength = -1;

            // Grab result lengths        
            var result = SetPassword(service, account, password, NULL_BUFFER, ref errorLength);

            // Build the error buffer
            var errorBuffer = errorLength > -1 ? new StringBuilder(errorLength) : null;

            if (result != KeytarResult.Success) {
                // Request the actual results
                result = SetPassword(service, account, password, errorBuffer, ref errorLength);

                // Move the results to strings
                error = errorBuffer?.ToString() ?? null;
            }

            // Return
            return result == KeytarResult.Success;
        }

        public static bool TryDeletePassword(string service, string account, out string error)
        {
            error = null;
            int errorLength = -1;

            // Grab result lengths        
            var result = DeletePassword(service, account, NULL_BUFFER, ref errorLength);

            // Build the error buffer
            var errorBuffer = errorLength > -1 ? new StringBuilder(errorLength) : null;

            if (result != KeytarResult.Success) {
                // Request the actual results
                result = DeletePassword(service, account, errorBuffer, ref errorLength);

                // Move the results to strings
                error = errorBuffer?.ToString() ?? null;
            }

            // Return
            return result == KeytarResult.Success;
        }
    }
}
