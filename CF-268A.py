n = int(input())

home = []
away = []
count = 0

for _ in range(n):
	h, a = map(int, input().split())
	home.append(h)
	away.append(a)

for i in range(n):
	for j in range(n):
		if home[i] == away[j]:
			count+=1

print(count)