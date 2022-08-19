st = input()
ex = list()
count = 0
for i in range(len(st)):
	if st[i] not in ex:
		ex.append(st[i])
		count+=1

if (count%2)==0:
	print('CHAT WITH HER!')
else:
	print('IGNORE HIM!')