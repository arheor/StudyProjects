# Image Posterization-----------------------------------------------------------

library(jpeg)
library(reshape)
library(ggplot2)


#������� ��������� ����������� �� �����
imageLoaderLocal <- function(nm){
  readImage <- readJPEG(sprintf("C:/R/lr3/img_R/%s.jpg", nm))  
  
  longImage <- melt(readImage)
  rgbImage <- reshape(longImage, timevar = "X3",
                      idvar = c("X1", "X2"), direction = "wide")
  rgbImage$X1 <- -rgbImage$X1
  return(rgbImage)
}


# Part 2 
# Identifying "dominant" colors with k-means

#�������� ����������� � rgbImage
# rgbImage <- imageLoader(allImageURLs[2]) # Pick one, or use your own URL.
rgbImage <- imageLoaderLocal(1)
with(rgbImage, plot(X2, X1, col = rgb(rgbImage[, 3:5]), asp = 1, pch = "."))

#����������� ����� ������������� k-�������. �� ��������� ��������� ��������� ���������� ������������ �� ������� ��������� ����� ��������� k = 3.
# Cluster in color space:
kColors <- 3 # Number of palette colors
kMeans <- kmeans(rgbImage[, 3:5], centers = kColors)

#������� ����� ������
# View clusters data
kMeans
factor(kMeans$cluster)

#������� ������ ���������� ��������
# k dominant colors
zp1 <- qplot(factor(kMeans$cluster), geom = "bar",
             fill = factor(kMeans$cluster))
zp1 <- zp1 + scale_fill_manual(values = rgb(kMeans$centers))
zp1

#�������� ������������ ����������� �������� ���������(�� ����������� �������� 3 �����)
# Posterization
approximateColor <- kMeans$centers[kMeans$cluster, ]
with(rgbImage, plot(X2, X1, col = rgb(approximateColor), asp = 1, pch = "."))


# Task 
# ��� �������, ����� ������������ �� ����������?
# � rgb() ����� ���� ������ ����. ������ ���� ���������� �� ���������


# K-Means vs Hierarchical clustering--------------------------------------------

library(cluster)

# Part 1
# Wine

# data(wine, package='rattle')
# wine
# saveRDS(wine, "Data/wine.RData")

#��������� � wine ������ �� wine.RData
wine <- readRDS("C:/R/lr3/Data/wine.RData")

#������������ �������
# To standardize the variables
wine.stand <- scale(wine[-1]) 

#��������� ������������� �-�������
# K-Means
k.means.fit <- kmeans(wine.stand, 3) # k = 3
#���������� ������ ���������� ����������
attributes(k.means.fit)

#������� ������ �������������
# Centroids:
k.means.fit$centers

#������� ������ ����� �����, ������������ �������, �������� �������� ������ �����.
# Clusters:
k.means.fit$cluster

#������� ���������� ����� � ������ ��������
# Cluster size:
k.means.fit$size

# Within groups sum of squares
wssplot <- function(data, nc = 15, seed = 1234) {
  wss <- (nrow(data) - 1) * sum(apply(data, 2, var))
  for (i in 2:nc) {
    set.seed(seed)
    wss[i] <- sum(kmeans(data, centers=i)$withinss)
  }
  plot(1:nc, wss, type = "b", xlab = "Number of Clusters",
       ylab = "Within groups sum of squares")
}

#������� ������ ����� ��������� ������ ������
wssplot(wine.stand, nc = 10) 

# Task 
# ������ �� �������, ����� ����������� ���������� ��������� � ������?
#2-3 ��������, ��� ��� ��� ���������>3 ������� ����� ��������� ���������� �����������

#������� 2� ������ ��������� ���������
# 2D representation of the Cluster solution
clusplot(wine.stand, k.means.fit$cluster, 
         main='2D representation of the Cluster solution',
         color=TRUE, shade=TRUE, labels=2, lines=0)

table(wine[, 1], k.means.fit$cluster)

# Task
# ��� ���������� �� �������?
# �������� �������� �� ���������
# � ��� ������� ������ �������?
# 

# �������� � d ��������� ������� ����������
# Hierarchical clustering
d <- dist(wine.stand, method = "euclidean") # Euclidean distance matrix.


# � H.fit ���������� ������, ����������� �� ������ �����
# ������� � ����� ��������� ��� ���� ��������� ���������� ������������ ������ ������� �������� ��������� ����������. 
# ����� ����������� �������� ���������� ���������� �� ��������� ���������� ������� �������� �� ����� ����������� �������� ��������. 
# ��� ��������� �����������. ����� � ���� ����� ������� ������������ �� ��������, 
# ��� ����������� ������� ���������� ���������� ������� ����� ����� ���������.
H.fit <- hclust(d, method = "ward.D2")

# ������� �����������(������������� ������)
plot(H.fit) # display dendogram

# ����� ����������� �� 3 ��������
groups <- cutree(H.fit, k = 3) # cut tree into 3 clusters

# ���������� ��������� �� �������
# Draw dendogram with red borders around the 3 clusters
rect.hclust(H.fit, k = 3, border = "red") 

# ������� ������� ����� ���������???
table(wine[, 1], groups)


# Part 2
# Protein

#��������� � ���������� food ������
food <- read.csv("C:/R/lr3/Data/protein.csv")

# ��� ������� ��������� �����, �������� ��������� ������ ��� ������� ��������� ��������� (������-)��������� �����.
set.seed(123456789) # to fix randomization

# ��������� ����� k-������� ������ � ����
# K-Means
# Only meat
grpMeat <- kmeans(food[ , c("WhiteMeat", "RedMeat")], centers = 3, nstart = 10)
grpMeat

#����������
# List of cluster assignments
o <- order(grpMeat$cluster)
data.frame(food$Country[o], grpMeat$cluster[o])

# ������ �������������
# Makes plot
plot(food$RedMeat, food$WhiteMeat, type = "n", xlim = c(3, 19), 
     xlab = "Red Meat", ylab = "White Meat")
text(x = food$RedMeat, y = food$WhiteMeat, 
     labels = food$Country, col = grpMeat$cluster + 1)

# Same analysis, but now with clustering on all protein groups 
# change the number of clusters to 7
grpProtein <- kmeans(food[ , -1], centers = 7, nstart = 10)
o <- order(grpProtein$cluster)
data.frame(food$Country[o], grpProtein$cluster[o])

clusplot(food[ , -1], grpProtein$cluster, 
         main = '2D representation of the Cluster solution',
         color = TRUE, shade = TRUE,
         labels = 2, lines = 0)

# ������������� ������������� ���
# Hierarchical clustering
foodagg <- agnes(food, diss = FALSE, metric = "euclidian")
plot(foodagg, main = "Dendrogram")

# ����� �� 4 ��������
groups <- cutree(foodagg, k = 4) # cut tree into 3 clusters
rect.hclust(foodagg, k = 4, border = "red")

# ������ ����������� �����
# Gaussian mixture models-------------------------------------------------------

library(mclust)

# ��������� � df ���������� ����� ������
df <- mtcars[, c("mpg", "hp")]

# �������� ���������� ������ ������ ����������� �����. ���������� ��������� ������������ �������
# Number of clusters is defined by the model
fit <- Mclust(df)
plot(fit, what = "classification")

#������� ��������
attributes(fit)
# ������� ������
summary(fit, parameter = TRUE)


# One variable
# Number of clusters 5
fit <- Mclust(df$mpg, G = 5)
plot(fit, what = "classification")

attributes(fit)
summary(fit, parameter = TRUE)
