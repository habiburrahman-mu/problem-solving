arr = input().split('+')
arr = sorted(arr)
ns = ""
for i in range(len(arr)-1):
	ns+=(arr[i])
	ns+='+'
ns+=(arr[len(arr)-1])
print(ns)