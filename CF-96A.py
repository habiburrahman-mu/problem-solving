st = input()
count = 1
last_ch = st[0]
for i in range(0, len(st)):
	if(st[i]==last_ch):
		count+=1
		if(count>=7):
			break
	else:
		count = 1
		last_ch = st[i]

if(count>=7):
	print('YES')
else:
	print('NO')