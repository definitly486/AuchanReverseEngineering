.class public interface abstract Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourInterface;
.super Ljava/lang/Object;
.source "BinaryContourInterface.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/boofcv/abst/filter/binary/BinaryContourInterface$Padded;
    }
.end annotation


# virtual methods
.method public abstract getContours()Ljava/util/List;
.end method

.method public abstract getMinContour(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;)Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;
.end method

.method public abstract loadContour(ILcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;)V
.end method

.method public abstract setConnectRule(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConnectRule;)V
.end method

.method public abstract setMaxContour(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;)V
.end method

.method public abstract setMinContour(Lcom/scanflow/datacapture/barinternal/boofcv/struct/ConfigLength;)V
.end method

.method public abstract setSaveInnerContour(Z)V
.end method
