library(e1071)
data<-read.csv("p12_12.csv",header=TRUE)

#par(mfrow=c(3,1))
#cor(data)
#pdf("Summary.pdf")
#plot(data)
#plot(data$DTRAD,type="l")

train<-data[1:292,]
test<-data[293:365,]

svm.model<-svm(DTRAD~.,data=train,cost=1000,gamma=0.0001)

svm.pred<-predict(svm.model, train[,-5])

svm.pred1<-predict(svm.model, test[,-5])


rmse <- function(error)
{
  sqrt(mean(error^2))
}

error<-(data$DTRAD[1:292] - svm.pred)
print(rmse(error))

error1<-(data$DTRAD[293:365] - svm.pred1)
print(rmse(error1))



tuneResult <- tune(svm, DTRAD ~ .,  data = data,
              ranges = list(epsilon = seq(0,1,0.1), cost = 2^(2:9))
)
print(tuneResult)

#pdf("x1.pdf")
#plot(tuneResult)
#dev.off()

tuneResult1 <- tune(svm, DTRAD ~ .,  data = data,
                   ranges = list(epsilon = seq(0,0.2,0.01), cost = 2^(2:9))) 
 
print(tuneResult)
#pdf("Summary.pdf")
#plot(data)
#plot(data$DTRAD,type="l")
#plot(tuneResult)
#plot(tuneResult1)
#dev.off()

tunedModel <- tuneResult$best.model
tunedModelY <- predict(tunedModel, train[,-5]) 
tunedModelY1 <- predict(tunedModel, test[,-5])
 


Results<-append(tunedModelY,tunedModelY1)
H=Results
A=20
r=15
PR=0.75
Energy = A * r * H * PR
results<-cbind(Results,Energy)

write.csv(results,"Results.csv",row.names=TRUE)
data<-read.csv("Results.csv")
names(data)<-c("Day_Number", "DTRAD","Energy")
write.csv(data,"Results.csv",row.names=FALSE)




#error <- data$DTRAD - tunedModelY  
#tunedModelRMSE <- rmse(error)
#print(tunedModelRMSE)
