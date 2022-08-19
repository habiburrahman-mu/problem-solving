n = int(input())
count = 0
st = input()
for i in range(n-1):
	if st[i]==st[i+1]:
		count+=1

print(count)