library(MASS)
library("neuralnet")
library(nnet)

data<-read.csv("p12_12.csv",header=TRUE)

data$RH<-as.numeric(data$RH)

#data<-sort(data[,5])

train<-(data[1:250,-4]) 
test<-(data[251:330,c(-5,-4)])

#new_train<-scale(train,center=TRUE,scale=TRUE);
#new_test<-scale(test,center=TRUE,scale=TRUE);

#response<-data$DTRAD
#resp_ind1<-class.ind(response[1:250])
#resp_ind2<-(response[251:330])

model<-neuralnet(DTRAD~DBT+DPT+RH, data=train, hidden =4, lifesign = "minimal", linear.output = FALSE, threshold = 0.1)
#pdf("model.pdf")
plot(model, rep = "best")
#dev.off()

pred1<-compute(model,train[,1:3])

#result1<-data.frame(actual=test$DTRAD,prediction=pred1$net.result)



#pred2 <- compute(model,test)






#d<-table(pred1,train[,4])
#acc1<-sum((diag(d)))/sum(d)
#print(acc1)

#pred<-predict(model,new_test,type="raw")
#t1<-table(rowSums(pred),resp_ind2)
#acc<-sum((diag(t1)))/sum(t1)
#print(acc)

