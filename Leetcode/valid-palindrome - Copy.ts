function isPalindrome(s: string): boolean {
    s = s.replace(/[\W_]/g, '').toLowerCase();
    for (let i = 0; i < s.length / 2; i++) {
        if (s[i] != s[s.length - i - 1]) {
            return false;
        }
    }
    return true;
};

var str = "A man, a plan, a canal: Panama"
console.log(isPalindrome(str));