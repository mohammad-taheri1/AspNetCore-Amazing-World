// اعتبارسنجی شمراه شبا - ورژن اول
#region IsValidShebaAccountV1
private bool IsValidShebaAccountV1(string shebaAccount)
{
    if (shebaAccount == null || shebaAccount.Length != 26)
        return false;

    bool isValidRegexFormat = new Regex(@"^IR\d{24}$").IsMatch(shebaAccount);

    return isValidRegexFormat;
}
#endregion


// اعتبارسنجی شمراه شبا - ورژن دوم
#region IsValidShebaAccountV2
private bool IsValidShebaAccountV2(string shebaAccount)
{
    if (shebaAccount == null || shebaAccount.Length != 26)
        return false;

    bool isValidRegexFormat = new Regex(@"^IR\d{24}$").IsMatch(shebaAccount);
    if (!isValidRegexFormat)
        return false;

    var convertedShebaString = shebaAccount.Substring(4, 22) + "1827" + shebaAccount.Substring(2, 2);
    var convertedShebaNumber = BigInteger.Parse(convertedShebaString);
    bool IsValidLogicalShebaAccount = (convertedShebaNumber % 97) == 1;
    if (!IsValidLogicalShebaAccount)
        return false;

    return true;
}
#endregion