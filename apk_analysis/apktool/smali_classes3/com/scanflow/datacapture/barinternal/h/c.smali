.class public abstract Lcom/scanflow/datacapture/barinternal/h/c;
.super Ljava/lang/Object;
.source "SourceFile"


# static fields
.field public static final a:Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

.field public static final b:Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

.field public static final c:Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

.field public static final d:Lcom/scanflow/datacapture/barinternal/kotlin/Pair;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 1
    const-string v0, "expiry_date"

    const-string v1, ""

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/TuplesKt;->to(Ljava/lang/Object;Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/h/c;->a:Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    const-string v0, "expiry_message"

    const-string v1, "The Scanflow SDK licence validation failed. Your licence key has expired!"

    invoke-static {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/TuplesKt;->to(Ljava/lang/Object;Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/h/c;->b:Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    const/16 v0, 0x1e

    invoke-static {v0}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v0

    const-string v1, "default_expiryday"

    invoke-static {v1, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/TuplesKt;->to(Ljava/lang/Object;Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/h/c;->c:Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    sget-object v0, Ljava/lang/Boolean;->TRUE:Ljava/lang/Boolean;

    const-string v1, "restrict_scan"

    invoke-static {v1, v0}, Lcom/scanflow/datacapture/barinternal/kotlin/TuplesKt;->to(Ljava/lang/Object;Ljava/lang/Object;)Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    move-result-object v0

    sput-object v0, Lcom/scanflow/datacapture/barinternal/h/c;->d:Lcom/scanflow/datacapture/barinternal/kotlin/Pair;

    return-void
.end method
