n = int(input())
count = 0
for i in range(n):
	u1, u2, u3 = map(int, input().split())
	if (u1+u2+u3) >=2:
		count=count+1

print(count)