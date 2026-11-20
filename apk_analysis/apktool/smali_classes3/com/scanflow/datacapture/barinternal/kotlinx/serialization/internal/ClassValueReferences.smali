.class final Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ClassValueReferences;
.super Ljava/lang/ClassValue;
.source "Caching.kt"


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 78
    invoke-direct {p0}, Ljava/lang/ClassValue;-><init>()V

    return-void
.end method


# virtual methods
.method protected computeValue(Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/MutableSoftReference;
    .locals 1

    const-string v0, "type"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 80
    new-instance p1, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/MutableSoftReference;

    invoke-direct {p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/MutableSoftReference;-><init>()V

    return-object p1
.end method

.method public bridge synthetic computeValue(Ljava/lang/Class;)Ljava/lang/Object;
    .locals 0

    .line 77
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/ClassValueReferences;->computeValue(Ljava/lang/Class;)Lcom/scanflow/datacapture/barinternal/kotlinx/serialization/internal/MutableSoftReference;

    move-result-object p1

    return-object p1
.end method
