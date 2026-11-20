.class public final Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid$Companion;
.super Ljava/lang/Object;
.source "Uuid.kt"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Companion"
.end annotation


# direct methods
.method private constructor <init>()V
    .locals 0

    .line 284
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public synthetic constructor <init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid$Companion;-><init>()V

    return-void
.end method


# virtual methods
.method public final fromLongs(JJ)Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;
    .locals 6

    const-wide/16 v0, 0x0

    cmp-long v2, p1, v0

    if-nez v2, :cond_0

    cmp-long v0, p3, v0

    if-nez v0, :cond_0

    .line 313
    invoke-virtual {p0}, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid$Companion;->getNIL()Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;

    move-result-object p1

    return-object p1

    .line 315
    :cond_0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;

    const/4 v5, 0x0

    move-wide v1, p1

    move-wide v3, p3

    invoke-direct/range {v0 .. v5}, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;-><init>(JJLkotlin/jvm/internal/DefaultConstructorMarker;)V

    return-object v0
.end method

.method public final getNIL()Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;
    .locals 1

    .line 291
    invoke-static {}, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;->access$getNIL$cp()Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;

    move-result-object v0

    return-object v0
.end method

.method public final parse(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;
    .locals 3

    const-string v0, "uuidString"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 398
    invoke-virtual {p1}, Ljava/lang/String;->length()I

    move-result v0

    const/16 v1, 0x20

    if-eq v0, v1, :cond_1

    const/16 v1, 0x24

    if-ne v0, v1, :cond_0

    .line 399
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/UuidKt__UuidJVMKt;->uuidParseHexDash(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;

    move-result-object p1

    return-object p1

    .line 401
    :cond_0
    new-instance v0, Ljava/lang/IllegalArgumentException;

    .line 402
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "Expected either a 36-char string in the standard hex-and-dash UUID format or a 32-char hexadecimal string, but was \""

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const/16 v2, 0x40

    .line 403
    invoke-static {p1, v2}, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/UuidKt__UuidKt;->access$truncateForErrorMessage(Ljava/lang/String;I)Ljava/lang/String;

    move-result-object v2

    .line 402
    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 403
    const-string v2, "\" of length "

    .line 402
    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    .line 403
    invoke-virtual {p1}, Ljava/lang/String;->length()I

    move-result p1

    .line 402
    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(I)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object p1

    .line 401
    invoke-direct {v0, p1}, Ljava/lang/IllegalArgumentException;-><init>(Ljava/lang/String;)V

    throw v0

    .line 400
    :cond_1
    invoke-static {p1}, Lcom/scanflow/datacapture/barinternal/kotlin/uuid/UuidKt__UuidJVMKt;->uuidParseHex(Ljava/lang/String;)Lcom/scanflow/datacapture/barinternal/kotlin/uuid/Uuid;

    move-result-object p1

    return-object p1
.end method
