# Image Posterization-----------------------------------------------------------

library(jpeg)
library(reshape)
library(ggplot2)


#функция загружает изображения из папки
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

#помещает изрбражение в rgbImage
# rgbImage <- imageLoader(allImageURLs[2]) # Pick one, or use your own URL.
rgbImage <- imageLoaderLocal(1)
with(rgbImage, plot(X2, X1, col = rgb(rgbImage[, 3:5]), asp = 1, pch = "."))

#Выполняется метод кластеризации k-средних. Он разбивает множество элементов векторного пространства на заранее известное число кластеров k = 3.
# Cluster in color space:
kColors <- 3 # Number of palette colors
kMeans <- kmeans(rgbImage[, 3:5], centers = kColors)

#выводим набор данных
# View clusters data
kMeans
factor(kMeans$cluster)

#выводим график значимости факторов
# k dominant colors
zp1 <- qplot(factor(kMeans$cluster), geom = "bar",
             fill = factor(kMeans$cluster))
zp1 <- zp1 + scale_fill_manual(values = rgb(kMeans$centers))
zp1

#проводим постеризацию изображения согласно кластерам(на изображении остается 3 цвета)
# Posterization
approximateColor <- kMeans$centers[kMeans$cluster, ]
with(rgbImage, plot(X2, X1, col = rgb(approximateColor), asp = 1, pch = "."))


# Task 
# Как сделать, чтобы постеризация не изменялась?
# В rgb() нужно явно задать цвет. Сейчас цвет выбирается из диапазона


# K-Means vs Hierarchical clustering--------------------------------------------

library(cluster)

# Part 1
# Wine

# data(wine, package='rattle')
# wine
# saveRDS(wine, "Data/wine.RData")

#загружаем в wine данные из wine.RData
wine <- readRDS("C:/R/lr3/Data/wine.RData")

#масштабируем столбцы
# To standardize the variables
wine.stand <- scale(wine[-1]) 

#выполняет кластеризацию к-средних
# K-Means
k.means.fit <- kmeans(wine.stand, 3) # k = 3
#возвращает список аттрибутов переменной
attributes(k.means.fit)

#выводит центры кластеризации
# Centroids:
k.means.fit$centers

#Выводит вектор целых чисел, обозначающий кластер, которому выделена каждая точка.
# Clusters:
k.means.fit$cluster

#выводит количество точек в каждом кластере
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

#выводит график суммы квадратов внутри группы
wssplot(wine.stand, nc = 10) 

# Task 
# Исходя из графика, какое оптимальное количество кластеров и почему?
#2-3 кластера, так как при кластерах>3 разница суммы квадратов становится минимальной

#выводит 2д график найденных кластеров
# 2D representation of the Cluster solution
clusplot(wine.stand, k.means.fit$cluster, 
         main='2D representation of the Cluster solution',
         color=TRUE, shade=TRUE, labels=2, lines=0)

table(wine[, 1], k.means.fit$cluster)

# Task
# Что изображено на графике?
# значения разбитые по кластерам
# О чём говорят данные таблицы?
# 

# помещаем в d евклидову матрицу расстояний
# Hierarchical clustering
d <- dist(wine.stand, method = "euclidean") # Euclidean distance matrix.


# В H.fit помещаются данные, вычисленные по методу Варда
# Сначала в обоих кластерах для всех имеющихся наблюдений производится расчёт средних значений отдельных переменных. 
# Затем вычисляются квадраты евклидовых расстояний от отдельных наблюдений каждого кластера до этого кластерного среднего значения. 
# Эти дистанции суммируются. Потом в один новый кластер объединяются те кластера, 
# при объединении которых получается наименьший прирост общей суммы дистанций.
H.fit <- hclust(d, method = "ward.D2")

# выводит дендограмму(иерархическое дерево)
plot(H.fit) # display dendogram

# делит дендограмму на 3 кластера
groups <- cutree(H.fit, k = 3) # cut tree into 3 clusters

# отображает изменения на графике
# Draw dendogram with red borders around the 3 clusters
rect.hclust(H.fit, k = 3, border = "red") 

# выводит таблицу групп кластеров???
table(wine[, 1], groups)


# Part 2
# Protein

#загружает в переменнюу food данные
food <- read.csv("C:/R/lr3/Data/protein.csv")

# эта функция фиксирует число, служащее начальной точкой для запуска алгоритма генерации (псевдо-)случайных чисел.
set.seed(123456789) # to fix randomization

# применяем метод k-средних только к мясу
# K-Means
# Only meat
grpMeat <- kmeans(food[ , c("WhiteMeat", "RedMeat")], centers = 3, nstart = 10)
grpMeat

#сортировка
# List of cluster assignments
o <- order(grpMeat$cluster)
data.frame(food$Country[o], grpMeat$cluster[o])

# график кластеризации
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

# иерархическая кластеризация еды
# Hierarchical clustering
foodagg <- agnes(food, diss = FALSE, metric = "euclidian")
plot(foodagg, main = "Dendrogram")

# делит на 4 кластера
groups <- cutree(foodagg, k = 4) # cut tree into 3 clusters
rect.hclust(foodagg, k = 4, border = "red")

# модели гауссовской смеси
# Gaussian mixture models-------------------------------------------------------

library(mclust)

# загружаем в df встроенный набор данных
df <- mtcars[, c("mpg", "hp")]

# Проводим кластерный анализ модели гауссовской смеси. Количество кластеров определяется моделью
# Number of clusters is defined by the model
fit <- Mclust(df)
plot(fit, what = "classification")

#выводит атрибуты
attributes(fit)
# выводит модель
summary(fit, parameter = TRUE)


# One variable
# Number of clusters 5
fit <- Mclust(df$mpg, G = 5)
plot(fit, what = "classification")

attributes(fit)
summary(fit, parameter = TRUE)
