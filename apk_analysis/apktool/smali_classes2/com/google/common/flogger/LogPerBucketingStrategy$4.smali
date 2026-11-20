.class Lcom/google/common/flogger/LogPerBucketingStrategy$4;
.super Lcom/google/common/flogger/LogPerBucketingStrategy;
.source "LogPerBucketingStrategy.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/google/common/flogger/LogPerBucketingStrategy;->forKnownKeys(Ljava/lang/Iterable;)Lcom/google/common/flogger/LogPerBucketingStrategy;
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


# instance fields
.field final synthetic val$keyMap:Ljava/util/HashMap;


# direct methods
.method constructor <init>(Ljava/lang/String;Ljava/util/HashMap;)V
    .locals 0

    .line 143
    iput-object p2, p0, Lcom/google/common/flogger/LogPerBucketingStrategy$4;->val$keyMap:Ljava/util/HashMap;

    invoke-direct {p0, p1}, Lcom/google/common/flogger/LogPerBucketingStrategy;-><init>(Ljava/lang/String;)V

    return-void
.end method


# virtual methods
.method protected apply(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 1

    .line 146
    iget-object v0, p0, Lcom/google/common/flogger/LogPerBucketingStrategy$4;->val$keyMap:Ljava/util/HashMap;

    invoke-virtual {v0, p1}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method
