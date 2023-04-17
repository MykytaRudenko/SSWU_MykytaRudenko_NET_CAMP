﻿using Exercise2;

string textOfEmails = @"mykyta.rudenko04@gmail.com mail_mail@mail.com .hello@mail.com mail.@mail.com dudhfkd ...@gmail.ua Mykyta@mail fjhtjig@ @nure.ua abc.afaf.nure.ua";
string textOfAllCorrectEmails = "simple@example.com very.common@example.com disposable.style.email.with+symbol@example.com other.email-with-hyphen@example.com fully-qualified-domain@example.com user.name+tag+sorting@example.com x@example.com example-indeed@strange-example.com admin@mailserver1 example@s.example \" \"@example.org \"john..doe\"@example.org mailhost!username@example.org user%example.com@example.org";
string textOfAllUncorrectEmails = "Abc.example.com A@b@c@example.com a\"b(c)d,e:f;g<h>i[j\\k]l@example.com this is \"not\\allowed@example.com this\\ still\"not\\allowed@example.com 1234567890123456789012345678901234567890123456789012345678901234+x@example.com i_like_underscore@but_its_not_allow_in _this_part.example.com";
EmailAddressChecker emailChecker = new EmailAddressChecker(textOfEmails);
Console.WriteLine(emailChecker);
Console.WriteLine(new string('-',50));
emailChecker = new EmailAddressChecker(textOfAllCorrectEmails);
Console.WriteLine(emailChecker);
Console.WriteLine(new string('-',50));
emailChecker = new EmailAddressChecker(textOfAllUncorrectEmails);
Console.WriteLine(emailChecker);

