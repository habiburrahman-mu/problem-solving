n, k = map(int, input().split())
count = 0
h = list(map(int, input().split()))
for i in range(n):
	if h[i]>0 and h[i]>=h[k-1]:
		count=count+1
print(count)