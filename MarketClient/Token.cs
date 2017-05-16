namespace MarketClient
{
    internal class Token
    {
        private string PrivateKey = @"-----BEGIN RSA PRIVATE KEY-----
MIICXQIBAAKBgQCo+sK/ihfYon83j5CxK5toHcvmLKj2hQuxOgBysiIByyEhDoki
aVAUXX2Dyt5HenE7KPfoLcjGKsL+iP1WKzp/uaR8EV8avtk5W6QXeCUQMDXRfB6D
kIXQfbeaGIhyNlRz1OCOr8W+zGDKCJNGesTMu3c/jw/GKENZfCjT1GGWgQIDAQAB
AoGAFrkp6TH7xPENJH6U2Y5gpp6jJb/JtOTtTpbbKpFTy2Pyf4yB2nPJBgQQdeGZ
BImtomP++mT1w9hKQopPbv//LKfoZvdjqcjgAYPQFdNVY+6qIIVnXZveCNozuCZx
tp36tBDNJFctDOjP1kYIgTTLVAWyQ3w6z8m7RkbFBl7z6fUCQQDKzBkl+ZgSp6St
YzGAjSU8cAws9g1s3T9nFl5HbDgg1fkTo9LqKt+ywTU5RLxd0XWWw8VLAnRy/Eby
FQjWT5eXAkEA1U91Ml8dZUspJnc6g4Loiib9LqCpZvkYj7bdO1e+lK+ZLraOgYFO
iD7ZVnk7rMBssj5hPb1vyTtWOExnRXZFpwJBAIlOuXRJ01pGIay37athZaXPI59J
lXtxLd2JepoXPsWUusk+ca7VCpMIWBYHYRaQnHJQ6QNJjTjRcOO1tD8Oss8CQQDH
6rZeRUKZor2obWoLw28Ju8ziHHVoKuFYH/xsF6poU8LvQu2Adp4Rl0W+g9Tn7Vhy
HYCpipfwM4p1LTZEpbpVAkA/bdGT5o4BtTf5PbS/o28wDXSPDKMlD8K1ONkRILAv
FFXG7+Gd5CBix71EUdrgZQFZPlepurrDZ6hlOPJmx0Of
-----END RSA PRIVATE KEY-----";
        private string user = "user26";
        public Token() {}
        public string CreatToken()
        {
            return Utils.SimpleCtyptoLibrary.CreateToken(user, PrivateKey);
        }
        public string getUser()
        {
            return user;
        }
    }
}
