using Exercise2;

string textOfEmails = @"mykyta.rudenko04@gmail.com mail_mail@mail.com .hello@mail.com mail.@mail.com dudhfkd ...@gmail.ua Mykyta@mail fjhtjig@.";
EmailAddressChecker emailChecker = new EmailAddressChecker();
emailChecker.CheckAddress(textOfEmails);
Console.WriteLine(emailChecker);