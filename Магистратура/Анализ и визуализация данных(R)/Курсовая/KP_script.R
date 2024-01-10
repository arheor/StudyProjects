library("ggplot2") # для построения графиков

#Загружаем набор данных
data <- read.csv("C:/R/CP/variant12.csv")

#проверка на пропуски
which(is.na(data)==T)

#Корреляции исходных переменных:
print(cor(data), digits = 2)

#описательная статистика
summary(data)

#применяем метод главных компонет
pca <- prcomp(data, scale = TRUE)

#Доля объясненной дисперсии
plot(cumsum(pca$sdev)/sum(pca$sdev), ylab = "Доля объясненной дисперсии")

#строим график главных компонент
plot(pca)

#проводим факторный анализ по 2 факторам на основе полученных данных
factanal(data,2)




# data <- read.csv("C:/R/CP/variant12.csv")
# data <- data[, -1]
# which(is.na(data)==T)
# summary(data)
# pca <- princomp(scale(data[,1:10]))
# plot(pca)
# factanal(data,3)






# Анализ главных компонент
# вводим данные в матрицу корреляции
fit <- princomp(data, cor=TRUE)
summary(fit) # print variance accounted for
loadings(fit) # pc loadings
plot(fit,type="lines") # scree plot
fit$scores # the principal components
biplot(fit)
# Maximum Likelihood Factor Analysis
# entering raw data and extracting 3 factors,
# with varimax rotation
fit <- factanal(data, 3,scores = "regression")
print(fit, digits=2, cutoff=.3, sort=TRUE)
# plot factor 1 by factor 2
load <- fit$loadings[,1:2]
plot(load,type="n") # set up plot
text(load,labels=names(data),cex=.7) # add variable names





pc<-princomp(scale(data),cor=TRUE)
data.0<-apply(data,2,function(x)(x-mean(x))/sd(x))
Sigma<-cov(data.0)
xtable(Sigma,caption="Корреляционная матрица.")
ei<-eigen(Sigma)
xtable(rbind(ei$values,cumsum(ei$values)/sum(ei$values)*100) 
       + caption="Собственные числа и суммарный вклад компонент в общую дисперсию.")
xtable(ei$vectors,caption="Собственные векторы.")
c(sum(ei$values),sum(diag(cov(data.0))))
Scores<-data.0 %*% ei$vectors
apply(Scores,2,var)
ei$values
factors<-apply(Scores,2, function(x) x/sd(x))
xtable(factors, caption="Значения главных компонент")
Matr<-apply(Scores,2,function(y)apply(data.0,2,function(x)cor(x,y)))
xtable(Matr, caption="Матрица факторных нагрузок")

