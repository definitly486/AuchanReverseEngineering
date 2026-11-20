.class public final Landroidx/collection/DoubleListKt;
.super Ljava/lang/Object;
.source "DoubleList.kt"


# static fields
.field private static final EmptyDoubleList:Landroidx/collection/DoubleList;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 888
    new-instance v0, Landroidx/collection/MutableDoubleList;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Landroidx/collection/MutableDoubleList;-><init>(I)V

    sput-object v0, Landroidx/collection/DoubleListKt;->EmptyDoubleList:Landroidx/collection/DoubleList;

    return-void
.end method

.method public static final buildDoubleList(ILkotlin/jvm/functions/Function1;)Landroidx/collection/DoubleList;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(I",
            "Lkotlin/jvm/functions/Function1<",
            "-",
            "Landroidx/collection/MutableDoubleList;",
            "Lcom/scanflow/datacapture/barinternal/kotlin/Unit;",
            ">;)",
            "Landroidx/collection/DoubleList;"
        }
    .end annotation

    const-string v0, "builderAction"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 981
    new-instance v0, Landroidx/collection/MutableDoubleList;

    invoke-direct {v0, p0}, Landroidx/collection/MutableDoubleList;-><init>(I)V

    invoke-interface {p1, v0}, Lkotlin/jvm/functions/Function1;->invoke(Ljava/lang/Object;)Ljava/lang/Object;

    return-object v0
.end method

.method public static final buildDoubleList(Lkotlin/jvm/functions/Function1;)Landroidx/collection/DoubleList;
    .locals 4
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lkotlin/jvm/functions/Function1<",
            "-",
            "Landroidx/collection/MutableDoubleList;",
            "Lcom/scanflow/datacapture/barinternal/kotlin/Unit;",
            ">;)",
            "Landroidx/collection/DoubleList;"
        }
    .end annotation

    const-string v0, "builderAction"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 964
    new-instance v0, Landroidx/collection/MutableDoubleList;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableDoubleList;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    invoke-interface {p0, v0}, Lkotlin/jvm/functions/Function1;->invoke(Ljava/lang/Object;)Ljava/lang/Object;

    return-object v0
.end method

.method public static final doubleListOf()Landroidx/collection/DoubleList;
    .locals 1

    .line 894
    sget-object v0, Landroidx/collection/DoubleListKt;->EmptyDoubleList:Landroidx/collection/DoubleList;

    return-object v0
.end method

.method public static final doubleListOf(D)Landroidx/collection/DoubleList;
    .locals 0

    .line 897
    invoke-static {p0, p1}, Landroidx/collection/DoubleListKt;->mutableDoubleListOf(D)Landroidx/collection/MutableDoubleList;

    move-result-object p0

    return-object p0
.end method

.method public static final doubleListOf(DD)Landroidx/collection/DoubleList;
    .locals 0

    .line 901
    invoke-static {p0, p1, p2, p3}, Landroidx/collection/DoubleListKt;->mutableDoubleListOf(DD)Landroidx/collection/MutableDoubleList;

    move-result-object p0

    return-object p0
.end method

.method public static final doubleListOf(DDD)Landroidx/collection/DoubleList;
    .locals 0

    .line 908
    invoke-static/range {p0 .. p5}, Landroidx/collection/DoubleListKt;->mutableDoubleListOf(DDD)Landroidx/collection/MutableDoubleList;

    move-result-object p0

    return-object p0
.end method

.method public static final varargs doubleListOf([D)Landroidx/collection/DoubleList;
    .locals 2

    const-string v0, "elements"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 912
    new-instance v0, Landroidx/collection/MutableDoubleList;

    array-length v1, p0

    invoke-direct {v0, v1}, Landroidx/collection/MutableDoubleList;-><init>(I)V

    .line 678
    iget v1, v0, Landroidx/collection/DoubleList;->_size:I

    invoke-virtual {v0, v1, p0}, Landroidx/collection/MutableDoubleList;->addAll(I[D)Z

    return-object v0
.end method

.method public static final emptyDoubleList()Landroidx/collection/DoubleList;
    .locals 1

    .line 891
    sget-object v0, Landroidx/collection/DoubleListKt;->EmptyDoubleList:Landroidx/collection/DoubleList;

    return-object v0
.end method

.method public static final mutableDoubleListOf()Landroidx/collection/MutableDoubleList;
    .locals 4

    .line 915
    new-instance v0, Landroidx/collection/MutableDoubleList;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableDoubleList;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    return-object v0
.end method

.method public static final mutableDoubleListOf(D)Landroidx/collection/MutableDoubleList;
    .locals 2

    .line 919
    new-instance v0, Landroidx/collection/MutableDoubleList;

    const/4 v1, 0x1

    invoke-direct {v0, v1}, Landroidx/collection/MutableDoubleList;-><init>(I)V

    .line 718
    invoke-virtual {v0, p0, p1}, Landroidx/collection/MutableDoubleList;->add(D)Z

    return-object v0
.end method

.method public static final mutableDoubleListOf(DD)Landroidx/collection/MutableDoubleList;
    .locals 2

    .line 926
    new-instance v0, Landroidx/collection/MutableDoubleList;

    const/4 v1, 0x2

    invoke-direct {v0, v1}, Landroidx/collection/MutableDoubleList;-><init>(I)V

    .line 718
    invoke-virtual {v0, p0, p1}, Landroidx/collection/MutableDoubleList;->add(D)Z

    .line 718
    invoke-virtual {v0, p2, p3}, Landroidx/collection/MutableDoubleList;->add(D)Z

    return-object v0
.end method

.method public static final mutableDoubleListOf(DDD)Landroidx/collection/MutableDoubleList;
    .locals 2

    .line 941
    new-instance v0, Landroidx/collection/MutableDoubleList;

    const/4 v1, 0x3

    invoke-direct {v0, v1}, Landroidx/collection/MutableDoubleList;-><init>(I)V

    .line 718
    invoke-virtual {v0, p0, p1}, Landroidx/collection/MutableDoubleList;->add(D)Z

    .line 718
    invoke-virtual {v0, p2, p3}, Landroidx/collection/MutableDoubleList;->add(D)Z

    .line 718
    invoke-virtual {v0, p4, p5}, Landroidx/collection/MutableDoubleList;->add(D)Z

    return-object v0
.end method

.method public static final varargs mutableDoubleListOf([D)Landroidx/collection/MutableDoubleList;
    .locals 2

    const-string v0, "elements"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 950
    new-instance v0, Landroidx/collection/MutableDoubleList;

    array-length v1, p0

    invoke-direct {v0, v1}, Landroidx/collection/MutableDoubleList;-><init>(I)V

    .line 678
    iget v1, v0, Landroidx/collection/DoubleList;->_size:I

    invoke-virtual {v0, v1, p0}, Landroidx/collection/MutableDoubleList;->addAll(I[D)Z

    return-object v0
.end method
