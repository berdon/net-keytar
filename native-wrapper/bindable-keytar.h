#ifndef SRC_BINDABLE_KEYTAR_H_
#define SRC_BINDABLE_KEYTAR_H_

#include "keytar.h"

#include <string>
#include <cstring>

extern "C"
{
    namespace NetKeytar
    {
        keytar::KEYTAR_OP_RESULT SetPassword(const char *service,
                                     const char *account,
                                     const char *password,
                                     char *error,
                                     int *errorLength);

        keytar::KEYTAR_OP_RESULT GetPassword(const char *service,
                                     const char *account,
                                     char *password,
                                     int *passwordLength,
                                     char *error,
                                     int *errorLength);

        keytar::KEYTAR_OP_RESULT DeletePassword(const char *service,
                                        const char *account,
                                        char *error,
                                        int *errorLength);

        keytar::KEYTAR_OP_RESULT FindPassword(const char *service,
                                      char *password,
                                      int *passwordLength,
                                      char *error,
                                      int *errorLength);

        // KEYTAR_OP_RESULT FindCredentials(const char* service,
        //                                  std::vector<Credentials>*,
        //                                  char* error);
    }
}

#endif // SRC_BINDABLE_KEYTAR_H_
