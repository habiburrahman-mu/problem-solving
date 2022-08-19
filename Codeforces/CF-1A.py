import math

m, n, a = map(int, input().split()) 
# The map() function executes a specified
# function for each item in an iterable.

res = math.ceil(m/float(a))*math.ceil(n/float(a))

print(res)