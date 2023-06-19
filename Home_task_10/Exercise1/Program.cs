using Exercise1;

var card = new Card(new int[]{ 4, 0, 0, 3, 7, 8, 9, 1, 0, 0, 2, 0, 5, 3, 8, 1});
var luhn = new LuhnAlgorithmValidator();
var american = new AmericanExpressValidator();
var master = new MasterCardValidator();
var visa = new VisaCardValidator();

luhn.SetSuccessor(american);
american.SetSuccessor(master);
master.SetSuccessor(visa);

bool isValid = luhn.Validate(card);
Console.WriteLine("Is valid: " + isValid);
Console.WriteLine("Card: " + card.ToString());
// string card
var card2 = new Card("4003789100205381");
isValid = luhn.Validate(card);
Console.WriteLine("Is valid: " + isValid);
Console.WriteLine("Card: " + card.ToString());
