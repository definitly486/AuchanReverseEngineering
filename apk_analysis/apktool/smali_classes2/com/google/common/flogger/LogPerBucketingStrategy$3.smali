.class Lcom/google/common/flogger/LogPerBucketingStrategy$3;
.super Lcom/google/common/flogger/LogPerBucketingStrategy;
.source "LogPerBucketingStrategy.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/common/flogger/LogPerBucketingStrategy;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "Lcom/google/common/flogger/LogPerBucketingStrategy<",
        "Ljava/lang/Object;",
        ">;"
    }
.end annotation


# direct methods
.method constructor <init>(Ljava/lang/String;)V
    .locals 0

    .line 69
    invoke-direct {p0, p1}, Lcom/google/common/flogger/LogPerBucketingStrategy;-><init>(Ljava/lang/String;)V

    return-void
.end method


# virtual methods
.method protected apply(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 73
    invoke-virtual {p1}, Ljava/lang/Object;->getClass()Ljava/lang/Class;

    move-result-object p1

    invoke-virtual {p1}, Ljava/lang/Class;->getName()Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method
