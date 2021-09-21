using System;
using System.Linq;
using Keytar;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        private static string TEST_SERVICE = "test-service";
        private static string TEST_ACCOUNT = "test-account";
        private static string ALLOWED_CHARS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ`1234567890-=~!@#$%^&*()_+[]\\{}|;':\",./<>?";

        [Fact]
        public void CanAddOrReplacePassword()
        {
            Assert.True(Password.TrySetPassword(TEST_SERVICE, TEST_ACCOUNT, GeneratePassword(10), out var error));
        }

        [Fact]
        public void CanDeletePassword()
        {
            // Need to have a password to delete
            CanAddOrReplacePassword();
            Assert.True(Password.TryDeletePassword(TEST_SERVICE, TEST_ACCOUNT, out var error));
        }

        [Fact]
        public void CanDeleteNonExistentPassword()
        {
            // Remove any existing password
            CanDeletePassword();
            Assert.False(Password.TryDeletePassword(TEST_SERVICE, TEST_ACCOUNT, out var error));
        }

        private static string GeneratePassword(int length) {
            var random = new Random(DateTime.Now.Millisecond);
            return new Char[length].Select(x => ALLOWED_CHARS[random.Next(ALLOWED_CHARS.Length)]).Aggregate("", (a, b) => a + b);
        }
    }
}
