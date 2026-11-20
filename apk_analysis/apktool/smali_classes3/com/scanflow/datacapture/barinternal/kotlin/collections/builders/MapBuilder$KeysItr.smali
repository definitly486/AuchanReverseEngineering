.class public final Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$KeysItr;
.super Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;
.source "MapBuilder.kt"

# interfaces
.implements Ljava/util/Iterator;
.implements Lkotlin/jvm/internal/markers/KMappedMarker;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "KeysItr"
.end annotation


# direct methods
.method public constructor <init>(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;)V
    .locals 1

    const-string v0, "map"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 539
    invoke-direct {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;-><init>(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;)V

    return-void
.end method


# virtual methods
.method public next()Ljava/lang/Object;
    .locals 2

    .line 541
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->checkForComodification$kotlin_stdlib()V

    .line 542
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->getIndex$kotlin_stdlib()I

    move-result v0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->getMap$kotlin_stdlib()Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    move-result-object v1

    invoke-static {v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->access$getLength$p(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;)I

    move-result v1

    if-ge v0, v1, :cond_0

    .line 543
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->getIndex$kotlin_stdlib()I

    move-result v0

    add-int/lit8 v1, v0, 0x1

    invoke-virtual {p0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->setIndex$kotlin_stdlib(I)V

    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->setLastIndex$kotlin_stdlib(I)V

    .line 544
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->getMap$kotlin_stdlib()Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;

    move-result-object v0

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;->access$getKeysArray$p(Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder;)[Ljava/lang/Object;

    move-result-object v0

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->getLastIndex$kotlin_stdlib()I

    move-result v1

    aget-object v0, v0, v1

    .line 545
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/collections/builders/MapBuilder$Itr;->initNext$kotlin_stdlib()V

    return-object v0

    .line 542
    :cond_0
    new-instance v0, Ljava/util/NoSuchElementException;

    invoke-direct {v0}, Ljava/util/NoSuchElementException;-><init>()V

    throw v0
.end method
