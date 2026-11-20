.class public final Lcom/scanflow/datacapture/barinternal/kotlin/Result;
.super Ljava/lang/Object;
.source "Result.kt"

# interfaces
.implements Ljava/io/Serializable;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;,
        Lcom/scanflow/datacapture/barinternal/kotlin/Result$Failure;
    }
.end annotation


# static fields
.field public static final Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;


# instance fields
.field private final value:Ljava/lang/Object;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;-><init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->Companion:Lcom/scanflow/datacapture/barinternal/kotlin/Result$Companion;

    return-void
.end method

.method private synthetic constructor <init>(Ljava/lang/Object;)V
    .locals 0

    .line 22
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->value:Ljava/lang/Object;

    return-void
.end method

.method public static final synthetic box-impl(Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlin/Result;
    .locals 1

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/Result;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;-><init>(Ljava/lang/Object;)V

    return-object v0
.end method

.method public static constructor-impl(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 0
    return-object p0
.end method

.method public static equals-impl(Ljava/lang/Object;Ljava/lang/Object;)Z
    .locals 2

    .line 0
    instance-of v0, p1, Lcom/scanflow/datacapture/barinternal/kotlin/Result;

    const/4 v1, 0x0

    if-nez v0, :cond_0

    return v1

    :cond_0
    check-cast p1, Lcom/scanflow/datacapture/barinternal/kotlin/Result;

    invoke-virtual {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->unbox-impl()Ljava/lang/Object;

    move-result-object p1

    invoke-static {p0, p1}, Lkotlin/jvm/internal/Intrinsics;->areEqual(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p0

    if-nez p0, :cond_1

    return v1

    :cond_1
    const/4 p0, 0x1

    return p0
.end method

.method public static final exceptionOrNull-impl(Ljava/lang/Object;)Ljava/lang/Throwable;
    .locals 1

    .line 64
    instance-of v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/Result$Failure;

    if-eqz v0, :cond_0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/kotlin/Result$Failure;

    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/Result$Failure;->exception:Ljava/lang/Throwable;

    return-object p0

    :cond_0
    const/4 p0, 0x0

    return-object p0
.end method

.method public static hashCode-impl(Ljava/lang/Object;)I
    .locals 0

    if-nez p0, :cond_0

    const/4 p0, 0x0

    return p0

    .line 0
    :cond_0
    invoke-virtual {p0}, Ljava/lang/Object;->hashCode()I

    move-result p0

    return p0
.end method

.method public static final isFailure-impl(Ljava/lang/Object;)Z
    .locals 0

    .line 38
    instance-of p0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/Result$Failure;

    return p0
.end method

.method public static final isSuccess-impl(Ljava/lang/Object;)Z
    .locals 0

    .line 32
    instance-of p0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/Result$Failure;

    xor-int/lit8 p0, p0, 0x1

    return p0
.end method

.method public static toString-impl(Ljava/lang/Object;)Ljava/lang/String;
    .locals 2

    .line 75
    instance-of v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/Result$Failure;

    if-eqz v0, :cond_0

    check-cast p0, Lcom/scanflow/datacapture/barinternal/kotlin/Result$Failure;

    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/Result$Failure;->toString()Ljava/lang/String;

    move-result-object p0

    return-object p0

    .line 76
    :cond_0
    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "Success("

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    invoke-virtual {v0, p0}, Ljava/lang/StringBuilder;->append(Ljava/lang/Object;)Ljava/lang/StringBuilder;

    const/16 p0, 0x29

    invoke-virtual {v0, p0}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p0

    return-object p0
.end method


# virtual methods
.method public equals(Ljava/lang/Object;)Z
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->value:Ljava/lang/Object;

    invoke-static {v0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->equals-impl(Ljava/lang/Object;Ljava/lang/Object;)Z

    move-result p1

    return p1
.end method

.method public hashCode()I
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->value:Ljava/lang/Object;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->hashCode-impl(Ljava/lang/Object;)I

    move-result v0

    return v0
.end method

.method public toString()Ljava/lang/String;
    .locals 1

    .line 73
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->value:Ljava/lang/Object;

    invoke-static {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->toString-impl(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public final synthetic unbox-impl()Ljava/lang/Object;
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/Result;->value:Ljava/lang/Object;

    return-object v0
.end method
