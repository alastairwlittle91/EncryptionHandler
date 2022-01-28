# EncryptionHandler
Basic AES Encrypt / Decrypt functions and .NET Core helper functions.

Register the Encryption service with `AddEncryptionService` passing in the encryption key that should be used.

Then implement the `IEncryptionService` wherever you need the encryption functionality.
