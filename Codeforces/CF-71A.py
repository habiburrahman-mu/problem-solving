n = int(input())
for i in range(n):
	st = input()
	if len(st) > 10:
		print(f"{st[0]}{len(st)-2}{st[len(st)-1]}")
	else:
		print(st)