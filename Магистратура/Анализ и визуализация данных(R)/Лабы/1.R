# 1. Загрузка данных
data <- read.csv("C://R/train.csv", header = TRUE, sep = ",")
# 2. Просмотр данных
View(data)
# 3. Есть ли среди данных пропуски?
# Ответ: да, есть
# 4. Создать новую переменную‐вектор, в которой будут 1, если
# значение в исходном векторе больше среднего, и –1, если значение
# переменной меньше среднего, и 0, если значение равно среднему.
ages <- data[["Age"]]
newages <- ifelse(ages > median(ages, na.rm = 1), 1, NA)
newages <- ifelse(ages == median(ages, na.rm = 1), 0, newages)
newages <- ifelse(ages < median(ages, na.rm = 1), -1, newages)
# Описательная статистика
summary(ages)
# График абсолютных частот
qplot(data$Age, xlab="Возраст", ylab="Значение")
# График плотности распределения
hist(data$Age, probability = TRUE, col="grey") 
