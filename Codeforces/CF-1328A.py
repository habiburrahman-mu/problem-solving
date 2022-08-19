import math
t = int(input())

for _ in range(t):
	a, b = map(int, input().split())
	move = abs(math.ceil(a/b)*b - a)
	print(move)