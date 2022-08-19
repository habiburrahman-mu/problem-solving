st = input().lower()
vowels = ['a', 'o', 'y', 'e', 'u', 'i']
n_s = ""
for i in range(len(st)):
	if st[i] not in vowels:
		n_s+='.'
		n_s+=st[i]

print(n_s)