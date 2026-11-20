.class public final Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;
.super Ljava/lang/Object;
.source "Instant.kt"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "Failure"
.end annotation


# instance fields
.field private final error:Ljava/lang/String;

.field private final input:Ljava/lang/CharSequence;


# direct methods
.method public constructor <init>(Ljava/lang/String;Ljava/lang/CharSequence;)V
    .locals 1

    const-string v0, "error"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "input"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 722
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;->error:Ljava/lang/String;

    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;->input:Ljava/lang/CharSequence;

    return-void
.end method


# virtual methods
.method public toInstant()Lcom/scanflow/datacapture/barinternal/kotlin/time/Instant;
    .locals 4

    .line 724
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantFormatException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;->error:Ljava/lang/String;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const-string v2, " when parsing an Instant from \""

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    iget-object v2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantParseResult$Failure;->input:Ljava/lang/CharSequence;

    const/16 v3, 0x40

    invoke-static {v2, v3}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantKt;->access$truncateForErrorMessage(Ljava/lang/CharSequence;I)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    const/16 v2, 0x22

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(C)Ljava/lang/StringBuilder;

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/kotlin/time/InstantFormatException;-><init>(Ljava/lang/String;)V

    throw v0
.end method
