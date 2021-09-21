#include "keytar.h"
#include "bindable-keytar.h"

namespace NetKeytar {
    keytar::KEYTAR_OP_RESULT SetPassword(const char *service,
                                         const char *account,
                                         const char *password,
                                         char *error,
                                         int *errorLength) {
        std::string errorString = std::string(error);
        keytar::KEYTAR_OP_RESULT result = keytar::SetPassword(
            std::string(service),
            std::string(account),
            std::string(password),
            &errorString);
        
        if (result != keytar::SUCCESS)
        {
            if (error == NULL || errorLength == NULL || *errorLength < 0) {
                // No error length; set it
                *errorLength = errorString.size() + 1;
            }
            else {
                // We have a valid error length; use it
                strncpy(error, errorString.c_str(), *errorLength);
            }
        }
        else {
            // Success; invalidate the error length
            *errorLength = -1;
        }

        return result;
    }

    keytar::KEYTAR_OP_RESULT GetPassword(const char *service,
                                         const char *account,
                                         char *password,
                                         int *passwordLength,
                                         char *error,
                                         int *errorLength) {
        std::string passwordString = std::string(password);
        std::string errorString = std::string(error);

        keytar::KEYTAR_OP_RESULT result = keytar::GetPassword(
            std::string(service),
            std::string(account),
            &passwordString,
            &errorString);
        
        if (result != keytar::SUCCESS)
        {
            // Error; invalidate the password length
            *passwordLength = -1;

            if (error == NULL || errorLength == NULL || *errorLength < 0) {
                // No error length; set it
                *errorLength = errorString.size() + 1;
            }
            else {
                // We have an error length; use it
                strncpy(error, errorString.c_str(), *errorLength);
            }
        }
        else {
            // Success; invalidate the error length
            *errorLength = -1;

            if (password == NULL || passwordLength == NULL || *passwordLength < 0) {
                // No password length; set it
                *passwordLength = passwordString.size() + 1;
            }
            else {
                // We have a password length; use it
                strncpy(password, passwordString.c_str(), *passwordLength);
            }
        }

        return result;
    }

    keytar::KEYTAR_OP_RESULT DeletePassword(const char *service,
                                            const char *account,
                                            char *error,
                                            int *errorLength) {
        std::string errorString = std::string(error);

        keytar::KEYTAR_OP_RESULT result = keytar::DeletePassword(
            std::string(service),
            std::string(account),
            &errorString);
        
        if (result != keytar::SUCCESS)
        {
            if (error == NULL || errorLength == NULL || *errorLength < 0) {
                // No error length; set it
                *errorLength = errorString.size() + 1;
            }
            else {
                // We have an error length; use it
                strncpy(error, errorString.c_str(), *errorLength);
            }
        }
        else {
            // Success; invalidate the error length
            *errorLength = -1;
        }

        return result;
    }
}